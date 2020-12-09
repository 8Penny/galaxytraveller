
using UnityEngine;
using Utils;

namespace Objects {
      [System.Serializable]
      public abstract class EnvironmentElement
      {
            protected SerializableVector3 _position;
            protected SerializableVector3 _rotation;
            protected string _id;
            public SerializableVector3 position => _position;
            public SerializableVector3 rotation => _rotation;
            public string id => _id;
            public int type => _type;
            private int _type;

            public EnvironmentElement(Vector3 pos, Vector3 rot, string id, int type)
            {
                  _position = pos;
                  _rotation = rot;
                  _id = id;
                  _type = type;
            }
      }
}

