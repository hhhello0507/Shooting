namespace UnityEngine
{
    public static class GameObjectExtensions
    {
        public static GameObject[] GetChildren(this GameObject parent)
        {
            var children = new GameObject[parent.transform.childCount];

            for (var i = 0; i < parent.transform.childCount; i++)
            {
                children[i] = parent.transform.GetChild(i).gameObject;
            }

            return children;
        }

        public static GameObject GetChild(this GameObject parent, int position)
        {
            return parent.transform.GetChild(position).gameObject;
        }
    }
}