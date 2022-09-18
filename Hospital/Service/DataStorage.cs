using Hospital.Models;
using System;
using System.Collections.Generic;


using System.IO;
using System.Text.Json;
using System.Windows;

namespace Hospital.Service
{
    public class DataStorage
    {
        public const string USER_FILE = "human";

        public static void saveUser(User user)
        {
            string json = JsonSerializer.Serialize(user);
            writeInFile(USER_FILE, json, FileMode.OpenOrCreate);
        }
        public static User getUser()
        {
            string json = getData(USER_FILE);
            if (json.Length > 0)
            {
                var human = JsonSerializer.Deserialize<User>(json);
                return human;
            }
            return null;
        }


        public static string getData(string path)
        {
            string str = "";
            using (BinaryReader binaryReader = new BinaryReader(
                File.Open(path, FileMode.OpenOrCreate)))
            {
                try
                {
                    while (true)
                    {
                        str += binaryReader.ReadString();
                    }

                }
                catch (Exception e2) { }

            }
            return str;
        }
        public static void writeInFile(string path, string str, FileMode mode)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(
            File.Open(path, mode)))
            {
                binaryWriter.Write(str);
            }
        }
        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }
    }
}
