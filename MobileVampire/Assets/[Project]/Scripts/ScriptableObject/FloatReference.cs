using System;

[Serializable]
public class FloatReference
{
    public bool UseConstante = true;
    public float ConstanteValue;
    public FloatVariable Variable;

    public float Value
    {
        get { return UseConstante ? ConstanteValue : Variable.Value; }
    }
}

