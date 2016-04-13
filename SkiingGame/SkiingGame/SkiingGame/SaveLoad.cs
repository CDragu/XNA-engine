﻿using System.Device;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;


namespace SkiingGame
{
    class SaveLoad
    {
        StorageDevice device;
        string containerName = "MyGamesStorage";
        string filename = "mysave.sav";
        PlayField field;

        Sprite.Info info = new Sprite.Info();
        
        public SaveLoad(PlayField field, string action)
        {
            this.sprite = sprite;
            if (action == "SAVE")
                this.InitiateSave();
            else if (action == "LOAD")
                this.Load(sprite);
        }
        private void InitiateSave()
        {
            //if (!Guide.IsVisible)
            //{
            //    device = null;
                StorageDevice.BeginShowSelector(PlayerIndex.One, this.SaveToDevice, null);
            //}
        }
        //
        void SaveToDevice(IAsyncResult result)
        {
            device = StorageDevice.EndShowSelector(result);
            if (device != null && device.IsConnected)
            {
                //Sprite.Info info = new Sprite.Info();                
                //info = sprite.Save();
                IAsyncResult r = device.BeginOpenContainer(containerName, null, null);
                result.AsyncWaitHandle.WaitOne();
                StorageContainer container = device.EndOpenContainer(r);
                if (container.FileExists(filename))
                    container.DeleteFile(filename);
                Stream stream = container.CreateFile(filename);
                XmlSerializer serializer = new XmlSerializer(typeof(Sprite.Info));
                serializer.Serialize(stream, info);
                stream.Close();
                container.Dispose();
                result.AsyncWaitHandle.Close();
            }
        }

        /// <summary>
        /// Loading the Game
        /// </summary>
        /// <param name="sprite"></param>
        
        public void Load(Sprite sprite)
        {
            
            this.InitiateLoad();
        }
        private void InitiateLoad()
        {
            //if (!Guide.IsVisible)
            //{
            //    device = null;
                StorageDevice.BeginShowSelector(PlayerIndex.One, this.LoadFromDevice, null);
            //}
        }

        void LoadFromDevice(IAsyncResult result)
        {
            device = StorageDevice.EndShowSelector(result);
            IAsyncResult r = device.BeginOpenContainer(containerName, null, null);
            result.AsyncWaitHandle.WaitOne();
            StorageContainer container = device.EndOpenContainer(r);
            result.AsyncWaitHandle.Close();
            if (container.FileExists(filename))
            {
                Stream stream = container.OpenFile(filename, FileMode.Open);
                XmlSerializer serializer = new XmlSerializer(typeof(Sprite.Info));
                info = (Sprite.Info)serializer.Deserialize(stream);
                stream.Close();
                container.Dispose();
                //Update the game based on the save game file
                AfterLoad();
            }
        }
        public Sprite.Info AfterLoad()
        {
            return this.info;
        }
        

    }
}