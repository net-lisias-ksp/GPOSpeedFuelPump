# Goo Pumps & Oils' Speed Pump :: Change Log

* 2022-0421: 1.9.0.5 (LisiasT) for KSP >= 1.3.1
	+ A pretty lame mistake was detected and fixed.
	+ Closes issues:
		+ [#2](https://github.com/net-lisias-ksp/GPOSpeedPump/issues/2) NRE on Balance  	
* 2022-0418: 1.9.0.4 (LisiasT) for KSP >= 1.3.1
	+ Some naming problems that passed trough last release was fixed.
	+ Added a "Migration" tool to preserve crafts and games migrating from the previous `GPOSpeedFuelPump` releases.
	+ Implements the KSPe's new Compatibility Checks. 
* 2022-0415: 1.9.0.3 (LisiasT) for KSP >= 1.3.1
	+ Officially naming the thing to `GPOSpeedPump` / `Goo Pumps & Oils' Speed Pump`
	+ Added 3rd Party Support by zer0Kerbal.
	+ Moving from `KSPe` to `KSPe.Light`.
	+ Proceeding into adopting it on Forum.
* 2022-0411: 1.9.0.2 (LisiasT) for KSP >= 1.3.1
	+ ***DITCHED*** due a bad call on naming the thingy.
* 2022-0403: 1.9.0.1 (LisiasT) for KSP >= 1.3.1
	+ Adds KSPe facilities:
		- Logs
		- Installment checks
		- Abstracted GUI/GUILayout support
	+ Certifies the thing to work up to KSP 1.12.3 :)
	+ Certifies the thing to work down to KSP 1.3.1 
	+ Adds (experimental) support for Simple Fuel Switch.
* 2022-0403: 1.9.0.0 (LisiasT) for KSP >= 1.3.1
	+ Ditched as a new release was made in less than 24 hours.
* 2019-0723: 1.8.19 (hab136) for KSP 1.7.3
	+ Recompiled for KSP 1.7.3
* 2019-0102: 1.8.18 (hab136) for KSP 1.6.0
	+ Recompiled for KSP 1.6
* 2018-1108: 1.8.17 (hab136) for KSP 1.5.1
	+ Fixed divide-by-zero error (thanks linuxgurugamer)
	+ Optimization of loops (thanks linuxgurugamer)
	+ Removed unnecessary and possibly problematic "FOR" parts from ModuleManager configs (thanks linuxgurugamer)
* 2018-1104: 1.8.16 (hab136) for KSP 1.5.1
	+ Recompiled for KSP 1.5.1
* 2018-0819: 1.8.15 (hab136) for KSP 1.4.5
	+ Recompiled for KSP 1.4.5
* 2018-0715: 1.8.14 (hab136) for KSP 1.4.4
	+ Recompiled for KSP 1.4.4
	+ Don't transfer resources that have ResourceTransferMode.NONE
* 2018-0507: 1.8.13 (hab136) for KSP 1.4.3
	+ Recompiled for KSP 1.4.3
* 2018-0331: 1.8.12 (hab136) for KSP 1.4.1
	+ Recompiled for KSP 1.4.2
	+ Added action groups
	+ [gpo action groups](https://user-images.githubusercontent.com/5103358/38164209-985069b2-3509-11e8-92b0-985bbb673e27.png)
* 2018-0318: 1.8.11 (hab136) for KSP 1.4.1
	+ Recompiled for KSP 1.4.1
* 2017-1212: 1.8.10 (hab136) for KSP 1.3.1
	+ Fixed Module Manager ordering
* 2017-1023: 1.8.9 (hab136) for KSP 1.3.1
	+ Recompiled for KSP 1.3.1
* 2017-0527: 1.8.8 (hab136) for KSP 1.3.0
	+ Recompiled for KSP 1.3.  Be sure to update Module Manager!
* 2016-1218: 1.8.7 (hab136) for KSP 1.2.2
	+ Recompiled for KSP 1.2.2
* 2016-1102: 1.8.6 (hab136) for KSP 1.2.1
	+ Recompiled for KSP 1.2.1
* 2016-1012: 1.8.5 (hab136) for KSP 1.2
	+ recompiled for KSP 1.2 release
* 2016-0915: 1.8.4 (hab136) for KSP 1.2 PRE-RELEASE
	+ Recompiled for KSP 1.2.  No code changes needed.
* 2016-0630: 1.8.3 (hab136) for KSP 1.1.3
	+ Recompiled for KSP 1.1.3
* 2016-0604: 1.8.2 (hab136) for KSP 1.1.2
	+ Moved all MM configs to "Patches" subdirectory.  Please do a clean install of the mod so you don't end up with duplicates.
	+ Added default pump level config
	+ Fixed B9PartSwitch config to work with CryoTanks
	+ Fixed Modular Fuel Tanks config
	+ Add FOR[GPOSpeedFuelPump] to all MM configs
* 2016-0502: 1.8.1 (hab136) for KSP 1.1.2
	+ Recompiled for KSP 1.1.2
	+ Added support for ModulerFuelTanks
	+ add super-everything config (disabled by default)
	+ change NEEDS to FOR in MM configs
* 2016-0420: 1.8 (hab136) for KSP 1.1
	+ Add resources for Station Science (Kibbal)
	+ Compile against KSP 1.1 release
* 2016-0401: 1.7 (hab136) for KSP 1.1 PRE-RELEASE
	+ Code updates for KSP 1.1
	+ Changed "Pump Options" window positioning because buttons are on left side of popup now
	+ Ensured "Pump Options" window doesn't go off-screen
	+ Fix MM config - extra whitespace, missing "HAS"
* 2016-0303: 1.6 (hab136) for KSP 16
	+ Add exception handling
	+ Fix some MM configs (particularly the Interstellar fuel switch)
* 2016-0124: 1.5 (hab136) for KSP 16
	+ Respect resource lock
	+ Don't operate on NO_FLOW resources.
	+ Break up config file, add support for CRP resources, fuel switch, procedural tanks
	+ Updated to 16 pump levels (my game already had this, but source code had 8?)
* 2015-????: 2.14.1 (Gaius) for KSP 0.23.5
	+ Fixed (hopefully) compatibility issue with Modular Fuels/Real Fuels, or other mods that modify which resources a tank contains after loading, and added a sanity check to prevent pumping of antifuel in impossible circumstances that apparently occasionally happen anyway.
* 2014-????: 1.29.1 (Gaius) for KSP 0.23.5
	+ Added ability to selectively disable pumping or balancing of one or more resources on parts that have multiple kinds of resources in them, either from the options window or in the config files.
* 2014-????: 1.24.1 (Gaius) for KSP 0.23.5
	+ First public release.
