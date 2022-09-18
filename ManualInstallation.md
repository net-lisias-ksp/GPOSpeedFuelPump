---
permalink: /ManualInstallation.html
title: Manual Installation
description: the flat-pack Kiea instructions, written in Kerbalese, unusally present
tags: installation,directions,page,kerbal,ksp,zer0Kerbal,Lisias,zedK
---

<!-- ManualInstallation.md v1.1.8.1
Goo Pumps & Oils' Speed Pump (GPOSP)
created: 01 Oct 2019
updated: 11 Apr 2022 -->

<!-- based upon work by Lisias -->

# Goo Pumps & Oils' Speed Pump (GPOSP)

[Home](./index.md)

Allows you to automatically transfer or balance fuel.

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
    + GPOSpeedPump]
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
    * [Module Manager][mm] or [Module Manager /L][mml]
  * KSP.log
  ...
```

### Dependencies

* [KSP (API) Extensions][kspe]
* *either*
  * [Module Manager][mm]
  * [Module Manager /L][mml]

[kspe]: http://ksp.lisias.net/add-ons/KSPAPIExtensions "KSPAPIExtensions"
[mm]: https://forum.kerbalspaceprogram.com/index.php?/topic/50533-*/ "Module Manager"
[mml]: https://github.com/net-lisias-ksp/ModuleManager "Module Manager /L"