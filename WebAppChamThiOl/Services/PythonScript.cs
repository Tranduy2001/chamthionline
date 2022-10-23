﻿using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using IronPython.Runtime;
using IronPython;
using IronPython.Hosting;
using IronPython.Modules;
using IronPython.Compiler;
using IronPython.Zlib;
using IronPython.SQLite;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WebAppChamThiOl.Models;

namespace WebAppChamThiOl.Services
{
    public class PythonScript
    {
        private ScriptEngine _engine;

        public PythonScript()
        {
            _engine = Python.CreateEngine();
        }

        public TResult RunFromString<TResult>(string code, string variableName)
        {
            // for easier debugging write it out to a file and call: _engine.CreateScriptSourceFromFile(filePath);
            ScriptSource source = _engine.CreateScriptSourceFromString(code, SourceCodeKind.Statements);
            CompiledCode cc = source.Compile();

            ScriptScope scope = _engine.CreateScope();
            cc.Execute(scope);

            return scope.GetVariable<TResult>(variableName);
        }
        public void RunCmdPython(string rootPath)
        {
            var processStartInfo = new ProcessStartInfo();
            var path = @$"{rootPath}";
            processStartInfo.WorkingDirectory = path;
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.Arguments = "/C python main.py";
            Process.Start(processStartInfo);

        }
        public DataResultViewModel GetDataRunCmd(string rootPath)
        {
            using (StreamReader r = new StreamReader($"{rootPath}\\data.json"))
            {
                string json = r.ReadToEnd();
                var temp = JsonConvert.DeserializeObject(json);
                var tamp2 = temp.ToString().Replace("\\", "");
                var data = (JObject)JsonConvert.DeserializeObject(tamp2);
                string sbd = data["data"]["sbd"].Value<string>();
                var result = data["data"]["answer"].ToString();
                var ketqua = new DataResultViewModel()
                {
                    SoBaoDanh = sbd
                };
                JObject converted = JsonConvert.DeserializeObject<JObject>(result);
                if (converted != null)
                {
                    Dictionary<string, string> keyValueMap = new Dictionary<string, string>();
                    foreach (KeyValuePair<string, JToken> keyValuePair in converted)
                    {
                        keyValueMap.Add(keyValuePair.Key, keyValuePair.Value.ToString());
                    }
                    ketqua.KetQua = keyValueMap;
                }
                return ketqua;
            }
        }
    }
}
