using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// static?
public class PlantController : MonoBehaviour
{
    public int Tend(Plant _plant)
    {
        _plant.state += 1;

        _plant.plantViewer.Refresh();
        return 0;
    }

    public int Unplant(Plant _plant)
    {
        if(_plant.state >= 3){
            _plant.state = 0;
            return 1;
        }
        _plant.state = 0;

        _plant.plantViewer.Refresh();
        return 0;
    }

    public int Water(Plant _plant)
    {
        _plant.watered = true;

        _plant.plantViewer.Refresh();
        return 0;
    }
}
