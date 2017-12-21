using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ScreenXY
{ 
    ////单例
    //private static ScreenXY instance;
    //public static ScreenXY Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = new ScreenXY();
    //        }
    //        return instance;
    //    }
    //}
    public static float MaxX { get { return GetWorldPos(new Vector3(0.98F, 0.98F, 0)).x; } }
    public static float MinX { get { return GetWorldPos(new Vector3(0.02F, 0.02F, 0)).x; } }
    public static float MaxY { get { return GetWorldPos(new Vector3(0.98F, 0.98F, 0)).y; } }
    public static float MinY { get { return GetWorldPos(new Vector3(0.02F, 0.02F, 0)).y; } }

    private static Vector3 GetWorldPos(Vector3 v)
    {
        return Camera.main.ViewportToWorldPoint(v);
    }
    //private ScreenXY()
    //{
    //    Vector3 rightUp = Camera.main.ViewportToWorldPoint(new Vector3(0.95F, 0.95F, 0));
    //    Vector3 leftDown = Camera.main.ViewportToWorldPoint(new Vector3(0.05F, 0.05F, 0));
    //    MaxX = rightUp.x;
    //    MinX = leftDown.x;
    //    MaxY = rightUp.y;
    //    MinY = leftDown.y;
    //}
    
}
