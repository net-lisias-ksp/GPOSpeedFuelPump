---
permalink: /ManualInstallation.html
title: Manual Installation
description: the flat-pack Kiea instructions, written in Kerbalese, unusally present
tags: installation,directions,page,kerbal,ksp,zer0Kerbal,Lisias,zedK
---
<!-- ManualInstallation.md v1.7.1.0
GPO Speed Pump (GPOSP)
created: 18 Sep 2022
updated: 26 Mar 2023

TEMPLATE: Marketing.md v1.0.2.0
created: 13 Apr 2022
updated: 27 Mar 2023

based upon work by Lisias

this file:
    CC BY-ND 4.0 by zer0Kerbal
    and used with express permission from zer0Kerbal -->

# Goo Pumps & Oils' Speed Pump (GPOSP)

[Home](./index.md)

Allows you to automatically transfer or balance fuel and requires using either [ModularManagement][MM] or [Module Manager][m-m].

## Installation Instructions

### Using CurseForge/OverWolf app or CKAN

You should be all good! (check for latest version on CurseForge)

### If Downloaded from CurseForge/OverWolf manual download

To install, place the GPO Speed Pump  folder inside your Kerbal Space Program's GameData folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**
  * Delete `<KSP_ROOT>/GameData/GPOSpeedPump`
* Extract the package's `GPOSpeedPump/` folder into your KSP's GameData folder as follows:
  * `<PACKAGE>/GPOSpeedPump` --> `<KSP_ROOT>/GameData/GPOSpeedPump`
    * Overwrite any preexisting folder/file(s).
  * you should end up with `<KSP_ROOT>/GameData/GPOSpeedPump`

### If Downloaded from SpaceDock / GitHub / other

To install, place the GameData folder inside your Kerbal Space Program folder:

* **REMOVE ANY OLD VERSIONS OF THE PRODUCT BEFORE INSTALLING**
  * Delete `<KSP_ROOT>/GameData/GPOSpeedPump`
* Extract the package's `GameData/GPOSpeedPump` folder into your KSP's root folder as follows:
  * `<PACKAGE>/GameData/GPOSpeedPump` --> `<KSP_ROOT>/GameData`
    * Overwrite any preexisting file.
  * you should end up with `<KSP_ROOT>/GameData/GPOSpeedPump`

## The following file layout must be present after installation

```markdown
<KSP_ROOT>
  + [GameData]
    + [GPOSpeedPump]
      + [Localization]
        ...
      + [Patches]
        ...
      * [GPOSpeedPump.dll]
      ...
      * License.txt
      * readme.htm
      * GPOSpeedPump.version
    ...
    * [ModularManagement (MM)][MM] or [Module Manager][m-m]
    * ModuleManager.ConfigCache
  * KSP.log
  ...
```

### Dependencies

* [KSP (API) Extensions][kspe]
* *either*
  * [ModularManagement][MM]
  * [Module Manager][m-m]

[kspe]: http://ksp.lisias.net/add-ons/KSPAPIExtensions "KSPAPIExtensions"
[MM]: https://github.com/net-lisias-ksp/ModularManagement "ModularManagement (MM)"
[m-m]: https://forum.kerbalspaceprogram.com/index.php?/topic/50533-*/ "Module Manager"