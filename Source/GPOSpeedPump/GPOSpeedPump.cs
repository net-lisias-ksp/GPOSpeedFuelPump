/*
	This file is part of Goo Pumps & Oils' Speed Pump
		© 2022 Lisias T : http://lisias.net <support@lisias.net>
		© 2016-2019 hab136
		© 2015 Geordiepigeonowner
		© 2014 Gaius Goodspeed

	Goo Pumps & Oils' Speed Pump is licensed as follows:
		* GPL 3.0 : https://www.gnu.org/licenses/gpl-3.0.txt

	Goo Pumps & Oils' Speed Pump is distributed in the
	hope that it will be useful, but WITHOUT ANY WARRANTY; without even
	the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the GNU General Public License 3.0 along
	with Goo Pumps & Oils' Speed Pump. If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using KSP.Localization;

//using GUI = KSPe.UI.GUI;
//using GUILayout = KSPe.UI.GUILayout;

namespace GPOSpeedPump
{
	public class GPOSpeedPump : PartModule
	{
		private readonly int _winId = new System.Random ().Next (0x00010000, 0x7fffffff);
		private Rect _winPos = new Rect (Screen.width / 2, Screen.height / 2, 208, 16);
		private bool _winShow;
		private float _lastUpdate;
		private const float Tolerance = (float)0.0001;
        private const float minPumpLevel = 0f;
        private const float maxPumpLevel = 16f;

		private Dictionary<string, int> _resourceFlags;

		[KSPField (isPersistant = true, guiActive = true, guiActiveEditor = true, guiName = /* Pump Level */"#GPOSP-pumpLevel" 
					/*, groupDisplayName = "#GPOSP-DisplayNameV" + Version.Text, groupStartCollapsed = true*/), 
					UI_FloatRange (minValue = minPumpLevel, maxValue = maxPumpLevel, stepIncrement = 1f)]
		public float _pumpLevel;

		[KSPField (isPersistant = true, guiActive = true, guiActiveEditor = true, guiName = /* Pump is<space> */"#GPOSP-autoPump"), UI_Toggle (disabledText = /* Off */"#autoLOC_6001073", enabledText = /* On */"#autoLOC_6001074")]
		public bool _autoPump;

		[KSPField (isPersistant = true, guiActive = true, guiActiveEditor = true, guiName = /* Balance */"#GPOSP-autoBalance"), UI_Toggle (disabledText = /* Disabled */"#autoLOC_439840", enabledText = /* Enabled */"#autoLOC_439839")]
		public bool _autoBalance;

		[KSPAction(/* Pump ON*/"#GPOSP-PumpOn")]
        public void ActionPumpOn(KSPActionParam param)
        {
            _autoPump = true;
        }
		[KSPAction(/* Pump OFF */"#GPOSP-PumpOff")]
        public void ActionPumpOff(KSPActionParam param)
        {
            _autoPump = false;
        }
		[KSPAction(/* Toggle pump */"#GPOSP-PumpToggle")]
        public void ActionPumpToggle(KSPActionParam param)
        {
            _autoPump = !_autoPump;
        }

        [KSPAction(/* Balancing ON */"#GPOSP-BalanceOn")]
        public void ActionBalanceOn(KSPActionParam param)
        {
            _autoBalance = true;
        }
		[KSPAction(/* Balancing OFF */"#GPOSP-BalanceOff")]
        public void ActionBalanceOff(KSPActionParam param)
        {
            _autoBalance = false;
        }
		[KSPAction(/* Toggle balancing */"#GPOSP-BalanceToggle")]
        public void ActionBalanceToggle(KSPActionParam param)
        {
            _autoBalance = !_autoBalance;
        }

		[KSPAction(/* Increase pump level */"#GPOSP-PumpLevelInc")]
        public void ActionIncreasePumpLevel(KSPActionParam param)
        {
            _pumpLevel = Math.Min(maxPumpLevel, _pumpLevel + 1f);
        }
		[KSPAction(/* Decrease pump level */"#GPOSP-PumpLevelDec")]
        public void ActionDecreasePumpLevel(KSPActionParam param)
        {
            _pumpLevel = Math.Max(minPumpLevel, _pumpLevel - 1f);
        }



        private int GetResourceFlags (string resourceName, int mask)
		{
			try {
			if (_resourceFlags == null)
				_resourceFlags = new Dictionary<string, int> ();

			if (!_resourceFlags.ContainsKey (resourceName)) {
				string cfgValue = GameDatabase.Instance.GetConfigs ("PART").Single (c => c.name.Replace ('_', '.') == part.partInfo.name)
                                              .config.GetNodes ("MODULE").Single (n => n.GetValue ("name") == moduleName).GetValue (resourceName + "Flags");
				if (!String.IsNullOrEmpty (cfgValue)) {
					int flags;
					if (Int32.TryParse (cfgValue, out flags))
						_resourceFlags.Add (resourceName, flags);
					else
						SetResourceFlags (resourceName, -1);
				} else
					SetResourceFlags (resourceName, -1);
			}

			return _resourceFlags [resourceName] & mask;
			} catch (Exception e) {
				return 0;
			}
		}

		private void SetResourceFlags (string resourceName, int value)
		{
			if (_resourceFlags == null)
				_resourceFlags = new Dictionary<string, int> ();

			if (isFlowableResource (resourceName)) {
				_resourceFlags [resourceName] = value;
			} else { // don't operate on NO_FLOW resources like SolidFuel
				_resourceFlags [resourceName] = 0;
			}
		}

		public override void OnLoad (ConfigNode cn)
		{
			// KSP is booting up
			if (part.partInfo == null)
				return;

			foreach (PartResource pr in part.Resources) {
				string cfgValue = cn.GetValue (pr.resourceName + "Flags");
				if (!String.IsNullOrEmpty(cfgValue) && (Int32.TryParse(cfgValue, out int flags)))
					SetResourceFlags(pr.resourceName, flags);
			}
		}

		public override void OnSave (ConfigNode cn)
		{
			if (_resourceFlags == null)
				return;

			foreach (KeyValuePair<string, int> rf in _resourceFlags) if (rf.Value != -1)
			{
				string flagName = rf.Key + "Flags";
				cn.SetValue(flagName, (rf.Value & 3).ToString(), true);
			}
		}

		private bool isFlowableResource (string resourceName)
		{
			PartResourceDefinition resource = PartResourceLibrary.Instance.GetDefinition (resourceName);
			if (resource == null) {
				return false;
			}
			if (resource.resourceFlowMode == ResourceFlowMode.NO_FLOW) {
				return false;
			}
			if (resource.resourceFlowMode == ResourceFlowMode.NULL) {
				return false;
			}
            if (resource.resourceTransferMode == ResourceTransferMode.NONE)
            {
                return false;
            }
			return true;
		}

		private void DrawConfigWindow (int id)
		{
			GUIStyle style = new GUIStyle (GUI.skin.button) { padding = new RectOffset (8, 8, 4, 4) };

			GUILayout.BeginVertical ();
			{ 
				GUILayout.Label (part.partInfo.title);

				for (int i = part.Resources.Count - 1; i >= 0; --i)
				{
					PartResource pr = part.Resources[i];

					SetResourceFlags (pr.resourceName, GetResourceFlags (pr.resourceName, ~1) | (GUILayout.Toggle (GetResourceFlags (pr.resourceName, 1) == 1, Localizer.Format(/* Pump<space> */"#GPOSP-pump") + pr.resourceName) ? 1 : 0));
					SetResourceFlags (pr.resourceName, GetResourceFlags (pr.resourceName, ~2) | (GUILayout.Toggle (GetResourceFlags (pr.resourceName, 2) == 2, Localizer.Format(/* Balance<Space> */"#GPOSP-balance") + pr.resourceName) ? 2 : 0));
				}

				if (GUILayout.Button (Localizer.Format(/* Close */"#autoLOC_149410"), style, GUILayout.ExpandWidth (true))) {
					_winShow = false;
				}
			}
			GUILayout.EndVertical ();

			GUI.DragWindow ();
		}

		internal static Rect clampToScreen (Rect rect)
		{
			rect.x = Mathf.Clamp (rect.x, 0, Screen.width - rect.width);
			rect.y = Mathf.Clamp (rect.y, 0, Screen.height - rect.height);
			return rect;
		}

		private void OnGUI ()
		{
			if (_winShow) {
				GUI.skin = null;
				_winPos = clampToScreen (GUILayout.Window (_winId, _winPos, DrawConfigWindow, Localizer.Format(/* GPOSpeed Pump v */"#GPOSP-DisplayNameV") + Version.Text)); // if this doesn't work correctly, use one directly below
			}
		}

		[KSPEvent (guiActive = true, guiActiveEditor = true, guiName = "Pump Options")]
		public void ConfigurePump ()
		{
			if (!_winShow) {
				_winPos.xMin = Math.Min (Math.Max (0, vessel == null ? Screen.width - _winPos.width : Event.current.mousePosition.x + 180), Screen.width - _winPos.width);
				_winPos.yMin = Math.Min (Math.Max (0, Event.current.mousePosition.y), Screen.height - _winPos.height);
				_winPos.width = 208;
				_winPos.height = 16;
				_winShow = true;
			} else {
				_winShow = false;
			}
		}

		private void PumpOut (float secs)
		{
			for (int i = part.Resources.Count - 1; i >= 0; --i)
			{
				PartResource pumpRes = part.Resources[i];

				if (pumpRes.flowState) // don't operate if resource is locked
				{ 
					if (GetResourceFlags (pumpRes.resourceName, 1) == 1) for (int s = vessel.Parts.Count - 1; s >= 0; --s)
					{
						Part shipPart = vessel.Parts[s];
						float shipPartLevel = 0f;

						if (shipPart.Modules.Contains<GPOSpeedPump>())
						{
							GPOSpeedPump gpoSpeedPump = shipPart.Modules[typeof(GPOSpeedPump).Name] as GPOSpeedPump;
							if (gpoSpeedPump != null) shipPartLevel = gpoSpeedPump._pumpLevel;
						}

						if (shipPartLevel < _pumpLevel) for (int pr = shipPart.Resources.Count - 1; pr >= 0; --pr)
						{
							PartResource shipPartRes = shipPart.Resources[pr];
							if (shipPartRes.resourceName == pumpRes.resourceName
								&& shipPartRes.flowState // don't operate if resource is locked
								)
							{
								double give = Math.Min (Math.Min (shipPartRes.maxAmount - shipPartRes.amount, pumpRes.amount), Math.Min (pumpRes.maxAmount, shipPartRes.maxAmount) / 10.0 * secs);
								if (give > 0.0) // Sanity check.  Apparently some other mods happily set amount or maxAmount to... interesting values...
								{
									pumpRes.amount -= give;
									shipPartRes.amount += give;
								}
							}
						}
					}
				}
			}
		}

		private void Balance ()
		{
			for (int i = part.Resources.Count - 1; i >= 0; --i)
			{
				PartResource pumpRes = part.Resources[i];

				if (pumpRes.flowState) { // don't operate if resource is locked
					if (GetResourceFlags (pumpRes.resourceName, 2) == 2) {
						double resAmt = 0f;
						double resMax = 0f;

						for (int j = vessel.Parts.Count - 1; j >= 0; --j)
						{
							Part shipPart = vessel.Parts[j];

							if (shipPart.Modules.Contains<GPOSpeedPump>())
							{
								GPOSpeedPump gpoSpeedPump = shipPart.Modules[typeof(GPOSpeedPump).Name] as GPOSpeedPump;
								if ( gpoSpeedPump._autoBalance && ( Math.Abs ((gpoSpeedPump)._pumpLevel - _pumpLevel) < Tolerance ) )
									for (int k = shipPart.Resources.Count - 1; k >= 0; --k)
									{
										PartResource shipPartRes = shipPart.Resources[k];
										if (
											shipPartRes.resourceName == pumpRes.resourceName
											&& shipPartRes.flowState // don't operate if resource is locked
											)
										{
											resAmt += shipPartRes.amount;
											resMax += shipPartRes.maxAmount;
										}
									}
							}
						}

						if (resMax > 0) // Dont do anything if the resMax is zero
						{
							for (int j = vessel.Parts.Count - 1; j >= 0; --j)
							{
								Part shipPart = vessel.Parts[j];
								if (shipPart.Modules.Contains<GPOSpeedPump>())
								{
									GPOSpeedPump gpoSpeedPump = shipPart.Modules[typeof(GPOSpeedPump).Name] as GPOSpeedPump;
									if (gpoSpeedPump._autoBalance && Math.Abs(gpoSpeedPump._pumpLevel - _pumpLevel) < Tolerance)
										for (int i1 = shipPart.Resources.Count - 1; i1 >= 0; --i1)
										{
											PartResource shipPartRes = shipPart.Resources[i1];
											if (shipPartRes.resourceName == pumpRes.resourceName
												&& shipPartRes.flowState // don't operate if resource is locked
												)
												shipPartRes.amount = shipPartRes.maxAmount * resAmt / resMax;
										}
								}
							}
						}
					}
				}
			}
		}

		public override void OnUpdate ()
		{
			float now = Time.time;

			if (_autoPump && _pumpLevel > 0f)
				PumpOut (now - _lastUpdate);

			if (_autoBalance)
				Balance ();

			_lastUpdate = now;

			if (_winShow && !vessel.isActiveVessel) {
				_winShow = false;
			}
		}
	}
}
