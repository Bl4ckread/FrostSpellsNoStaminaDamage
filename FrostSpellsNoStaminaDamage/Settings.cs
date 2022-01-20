using System;
using System.Collections.Generic;
using System.Linq;
using Mutagen.Bethesda.Plugins;
using Mutagen.Bethesda.WPF.Reflection.Attributes;

namespace FrostSpellsNoStaminaDamage
{

    public class Settings
    {
        [MaintainOrder]

        private List<string> _ignored = new List<string>();
        [SettingName("Ignored mods")]
        [Tooltip("A list of mods that should not be patched. Each entry is a string matching a plugin name.")]
        public List<string> Ignored
        {
            get
            {
                return _ignored;
            }
            set
            {
                _ignored = value;
            }
        }

        private HashSet<ModKey>? _ignoredMods;

        public HashSet<ModKey> IgnoredMods
        {
            get
            {
                List<ModKey> modKeys = new List<ModKey>();
                IList<ModKey> modFiles = Program.State.LoadOrder.Keys.ToList();
                foreach (string modFilter in Ignored)
                {
                    if (modFilter != "")
                        modKeys.AddRange(modFiles.Where(modKey => modKey.FileName.String.Contains(modFilter, StringComparison.OrdinalIgnoreCase)));
                }
                _ignoredMods = new HashSet<ModKey>(modKeys);
                return _ignoredMods;
            }
        }
        public List<string[]> ParseIdFilters(IList<string> filterData)
        {
            List<string[]> result = new List<string[]>();
            foreach (var filterDataItem in filterData)
            {
                if (!String.IsNullOrEmpty(filterDataItem))
                {
                    string[] filterElements = filterDataItem.Split(',');
                    if (filterElements.Length > 0)
                    {
                        result.Add(filterElements);
                    }
                }
            }
            return result;
        }

        private List<string[]> _blacklist = new List<string[]>();
        [SettingName("Blacklisted EditorIDs")]
        [Tooltip("Each entry is a comma separated list of partial Magic Effect EditorIDs, case insensitive.")]
        public List<string> Blacklist
        {
            get
            {
                List<string> idFilters = new List<string>();
                foreach (var filter in _blacklist)
                {
                    idFilters.Add(String.Join(",", filter));
                }
                return idFilters;
            }
            set
            {
                _blacklist = ParseIdFilters(value);
            }
        }
    }



}
