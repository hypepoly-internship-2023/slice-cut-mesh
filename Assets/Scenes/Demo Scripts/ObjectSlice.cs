using UnityEngine;
using BzKovSoft.ObjectSlicer;

public class ObjectSlice : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        var sliceable = target.GetComponent<IBzSliceable>();
        if(sliceable != null)
        {
            sliceable.Slice(new Plane(Vector3.up, 0), null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
