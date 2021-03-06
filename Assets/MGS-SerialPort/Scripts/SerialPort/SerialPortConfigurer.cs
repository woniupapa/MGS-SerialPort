﻿/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SerialPortConfigurer.cs
 *  Description  :  Read config from local file and write config to
 *                  local file.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/4/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  10/3/2017
 *  Description  :  Use JsonUtility to serialize and deserialize config.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.2
 *  Date         :  3/2/2018
 *  Description  :  Optimize.
 *************************************************************************/

using System;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

#if !UNITY_5_3_OR_NEWER
using LitJson;
#endif

namespace Mogoson.IO.Ports
{
    /// <summary>
    /// Configurer of SerialPort.
    /// </summary>
    public static class SerialPortConfigurer
    {
        #region Field and Property
        /// <summary>
        /// Full path of serialport config file.
        /// </summary>
        public static readonly string ConfigPath = Application.streamingAssetsPath + "/Config/SerialPortConfig.json";
        #endregion

        #region Public Method
        /// <summary>
        /// Read SerialPortConfig from config file.
        /// </summary>
        /// <param name="config">Config of serialport.</param>
        /// <param name="error">Error message.</param>
        /// <returns>Read config succeed.</returns>
        public static bool ReadConfig(out SerialPortConfig config, out string error)
        {
            config = new SerialPortConfig();
            try
            {
                var json = File.ReadAllText(ConfigPath);
#if UNITY_5_3_OR_NEWER
                config = JsonUtility.FromJson<SerialPortConfig>(json);
#else
                config = JsonMapper.ToObject<SerialPortConfig>(json);
#endif
                error = string.Empty;
                Debug.Log("Read config succeed.");
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                Debug.LogError(error);
                return false;
            }
        }

        /// <summary>
        /// Write SerialPortConfig to config file.
        /// </summary>
        /// <param name="config">Config of serialport.</param>
        /// <param name="error">Error message.</param>
        /// <returns>Write config succeed..</returns>
        public static bool WriteConfig(SerialPortConfig config, out string error)
        {
            try
            {
#if UNITY_5_3_OR_NEWER
                var configJson = JsonUtility.ToJson(config);
#else
                var configJson = JsonMapper.ToJson(config);
#endif
                File.WriteAllText(ConfigPath, configJson);
#if UNITY_EDITOR
                AssetDatabase.Refresh();
#endif
                error = string.Empty;
                Debug.Log("Write config succeed.");
                return true;
            }
            catch (Exception e)
            {
                error = e.Message;
                Debug.LogError(error);
                return false;
            }
        }
        #endregion
    }
}