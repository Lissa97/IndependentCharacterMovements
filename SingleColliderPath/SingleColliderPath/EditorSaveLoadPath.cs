using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Text;

namespace SingleColliderPath
{
    [CustomEditor(typeof(ForceController))]
    internal class EditorSaveLoadPath : Editor
    {
        public override void OnInspectorGUI()
        {
            ForceController FC = (ForceController)target;

            DrawDefaultInspector();
            if (GUILayout.Button("Save Path"))
            {
                ForceController.Force[] data = FC.path.ToArray();
                XmlSerializer serializer = new XmlSerializer(typeof(ForceController.Force[]));
                FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/PathData.xml", FileMode.Create);
                TextWriter textWriter = new StreamWriter(stream, Encoding.UTF8);
                serializer.Serialize(textWriter, data);
                textWriter.Close();
            }
            if (GUILayout.Button("Load Path"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ForceController.Force[]));
                TextReader reader = new StreamReader(Application.dataPath + "/StreamingAssets/PathData.xml", Encoding.UTF8);
                string data = reader.ReadToEnd();
                StringReader stread = new StringReader(data);
                ForceController.Force[] path = (ForceController.Force[])serializer.Deserialize(stread);

                foreach (var f in path)
                {
                    FC.path.Add(f);
                }
            }

        }

    }

}
