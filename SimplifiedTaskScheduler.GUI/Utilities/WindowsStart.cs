using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace SimplifiedTaskScheduler.GUI.Utilities
{
    internal class WindowsStart
    {
        private static readonly string REG_RUN_STARTUP = @"Software\Microsoft\Windows\CurrentVersion\Run";
        public static bool IsSet(RegistryKey section, string name, string value)
        {
            RegistryKey myKey;
            string regValue;
            myKey = section.OpenSubKey(REG_RUN_STARTUP);
            if (myKey == null) return false;
            string[] values = myKey.GetValueNames();
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    regValue = (string)myKey.GetValue(values[i]);
                    if (value.ToLowerInvariant() == regValue.ToLowerInvariant())
                        return true;
                }
            }
            return false;
        }
        public static bool DeleteRegistryValue(RegistryKey section, string name, string value)
        {
            return DeleteRegistryValue(section, REG_RUN_STARTUP, name, value);
        }
        public static bool AddRegistryValue(RegistryKey section, string name, string value)
        {
            return AddRegistryValue(section, REG_RUN_STARTUP, name, value);
        }
        private static bool DeleteRegistryValue(RegistryKey section, string location, string name, string value)
        {
            RegistryKey myKey;
            string regValue;
            myKey = section.OpenSubKey(REG_RUN_STARTUP, true);
            if (myKey == null) return false;
            string[] values = myKey.GetValueNames();
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                {
                    regValue = (string)myKey.GetValue(values[i]);
                    if (value.ToLowerInvariant() == regValue.ToLowerInvariant())
                    {
                        myKey.DeleteValue(values[i], false);
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool AddRegistryValue(RegistryKey section, string location, string name, string value)
        {
            RegistryKey myKey;
            string[] nameParts;
            string nameIndexParts;
            int index;
            string fullName;
            int maxIndex = 0;
            string[] values;
            try
            {
                myKey = section.OpenSubKey(REG_RUN_STARTUP, true);
                if (myKey == null) return false;
                values = myKey.GetValueNames();
                for (int i = 0; i < values.Length; i++)
                {
                    if (values[i].StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        nameParts = values[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                        if (nameParts == null || nameParts.Length < 2) continue;
                        nameIndexParts = nameParts[1];
                        if (!int.TryParse(nameIndexParts, out index)) continue;
                        if (maxIndex < index) maxIndex = index;
                    }
                }
                fullName = name + " " + (maxIndex + 1).ToString();
                myKey.SetValue(fullName, value, RegistryValueKind.String);
                return true;
            }
            catch (Exception exc)
            {
                return false;
            }
            finally
            {
                section.Close();
            }
        }
    }
}
