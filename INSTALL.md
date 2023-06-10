# Goo Pumps & Oils' Speed Pump

Allows you to automatically transfer or balance fuel.


## Installation Instructions

To install, place the GameData folder inside your Kerbal Space Program folder. Optionally, you can also do the same for the PluginData (be careful to do not overwrite your custom settings):

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**, including any other fork:
	+ Delete `<KSP_ROOT>/GameData/GPOSpeedFuelPump`
		- if updating from the previous fork 
	+ Delete `<KSP_ROOT>/GameData/GPOSpeedPump`
* Extract the package's `GameData` folder into your KSP's root:
	+ `<PACKAGE>/GameData/*` --> `<KSP_ROOT>/GameData`

The following file layout must be present after installation:

```
<KSP_ROOT>
	+ [GameData]
		+ [GPOSpeedPump]
			...
			* CHANGE_LOG.md
			* LICENSE
			* NOTICE
			* README.md
			* GPOSpeedPump.dll
			* GPOSpeedPump.version
		* 000_KSPe.dll
		* ModuleManager.dll
		...
	* KSP.log
	* PartDatabase.cfg
	...
```


### Dependencies

* [Module Manager](https://github.com/net-lisias-ksp/ModuleManager)
	+ Not Included
