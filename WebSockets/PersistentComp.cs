using UnityEngine;

namespace WebSockets_Nika
{
    public class PersistentComp : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
