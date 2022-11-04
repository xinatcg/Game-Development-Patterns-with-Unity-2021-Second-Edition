using System;
using UnityEngine;

namespace Chapter.Singleton
{
    public class  Singleton<T> : 
        MonoBehaviour where T : Component {
        
        private static T _instance;

        public static T Instance
        {
            get
            {
                Debug.Log( "Singleton get @: " + DateTime.Now);
                if (_instance == null)
                {
                    Debug.Log( "Singleton get and null @: " + DateTime.Now);
                    _instance = FindObjectOfType<T>();

                    if (_instance == null)
                    {
                        Debug.Log( "Singleton create @: " + DateTime.Now);
                        GameObject obj = new GameObject();
                        obj.name = typeof(T).Name;
                        _instance = obj.AddComponent<T>();
                    }
                }
                else
                {
                    Debug.Log( "Singleton get and not null @: " + DateTime.Now);
                }

                return _instance;
            }
        }

        public virtual void Awake()
        {
            Debug.Log( "Singleton Awake @: " + DateTime.Now);
            if (_instance == null)
            {
                Debug.Log( "Singleton is null @: " + DateTime.Now);
                _instance = this as T;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.Log( "Singleton Destroy @: " + DateTime.Now);
                Destroy(gameObject);
            }
        }
    }
}