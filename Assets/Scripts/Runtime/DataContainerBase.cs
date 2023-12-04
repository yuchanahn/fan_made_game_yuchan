using System.Collections.Generic;
using UnityEngine;

namespace SJJ.GoogleSheetsDatabase
{
    public abstract class DataContainerBase : ScriptableObject
    {
        [SerializeField] [HideInInspector]
        public string documentID;
    }
}