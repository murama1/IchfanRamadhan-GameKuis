using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(fileName = "Player Progress", menuName = "Game Kuis/Player Progress")]
public class PlayerProgress : ScriptableObject
{



    [Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progressLevel;
    
    }

    public MainData progressData = new MainData();

    [SerializeField]
    private string _fileName = "contoh.txt";

    public void SimpanProgress()
    {
        //sampel data
        progressData.koin = 200;
        if (progressData.progressLevel == null) {
            progressData.progressLevel = new();
            progressData.progressLevel.Add("Level Pack 1", 3);
            progressData.progressLevel.Add("Level Pack 3", 5);
        
        }


        //informasi penyimpan data

        var directory = Application.dataPath + "/Temporary/";
        var path = directory + _fileName;

        
        //membuat directory temporary
        if (!Directory.Exists(directory)) { 
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been Created: " + directory); 
        }

        //membuat file baru
        if (!File.Exists(path)) { 
            File.Create(path).Dispose();
            Debug.Log("file created: " + path);
        
        }

        //var konten = $"{ progressData.koin}\n";

        var fileStream = File.Open(path, FileMode.Open);
        
        //*binary formatter
        var formatter = new BinaryFormatter(); //binary formatter method

        fileStream.Flush();
        formatter.Serialize(fileStream, progressData);
        // end of binary formatter */


       /* binary writer method
        //menyimpan data ke dalam file menggunakan binary writer
        var writer = new BinaryWriter(fileStream);

        writer.Write(progressData.koin);
        foreach (var i in progressData.progressLevel)
        {
            writer.Write(i.Key);
            writer.Write(i.Value);
        }


        //Putuskan aliran memori dengan File
        writer.Dispose(); 
        //binary writer method end */

        fileStream.Dispose();

        /* 
        foreach (var i in progressData.progressLevel)
        {
            konten += $"{i.Key} {i.Value}\n";

        }
        File.WriteAllText(path, konten);
        */

        Debug.Log($"{_fileName} Berhasil disimpan");
    }


    public bool MuatProgress()
    {
        //informasi untuk memuat data
        var directory = Application.dataPath + "/Temporary/";
        var path = directory + _fileName;

        //memuat data dari file menggunakan binary formatter
        var fileStream = File.Open(path, FileMode.OpenOrCreate);
        
        
        try
        {
            /* binary reader method
            var reader = new BinaryReader(fileStream);

            try 
            { 
                progressData.koin = reader.ReadInt32();
                if (progressData.progressLevel == null)
                {
                    progressData.progressLevel = new();
                
                }

                while (reader.PeekChar() != -1) 
                {
                    var namaLevelPack = reader.ReadString();
                    var levelKe = reader.ReadInt32();
                    progressData.progressLevel.Add(namaLevelPack, levelKe);
                    Debug.Log($"{namaLevelPack} : {levelKe}");
                
                }

                reader.Dispose();
            
            }


            catch (Exception e)
            {
                Debug.Log($"ERROR: terjadi kesalahan saat memuat progress {e.Message}");
                reader.Dispose();
                fileStream.Dispose( );
            }
            
            //binary reader method end */


            //* binary formatter method
            var formatter = new BinaryFormatter();

            progressData = (MainData)formatter.Deserialize(fileStream);

            //binary formatter end*/
            
            //putuskan aliran memori dengan file
            fileStream.Dispose();

            Debug.Log($"{progressData.koin}; {progressData.progressLevel.Count}");

            return true;
        }

        catch (Exception e) 
        { 
            Debug.Log($"ERROR: terjadi kesalahan saat memuat progress {e.Message}");

            //putuskan aliran memori dengan file
            fileStream.Dispose ();
            
            return false;

        }
        
    }

}
