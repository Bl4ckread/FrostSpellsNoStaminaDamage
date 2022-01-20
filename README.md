# FrostSpellsNoStaminaDamage

A Synthesis patcher for Skyrim that removes stamina damage from frost spells and other similar detrimental effects that have it as secondary actor value.

### Justification

When running a combat setup where the player and/or NPCs require stamina to attack, frost spells dealing stamina damage can be quite OP (and annoying). A simple frostbite will prevent the target from ever attacking. This patcher remedies that by removing stamina damage from all relevant magic effects.

Settings allow the user to provide a list of mod names and EditorIDs to ignore. Mod name is matched against the mod where the record was first introduced (i.e., skyrim.esm would ignore all spells from the original vanilla game (not those added in DLCs).
