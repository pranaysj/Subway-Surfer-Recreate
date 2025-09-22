using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentService 
{
    private EnvironmentController environmentController;

    public EnvironmentService(EnvironmentScriptableObject environmentScriptableObject)
    {
        environmentController = new EnvironmentController(environmentScriptableObject);
    }
}
