using System;
using UnityEngine;

public class IAPService : IIAPService
{
    public void Purchase(string productID, Action callbackSuccessful, Action callbackCancelled, Action callbackError)
    {
        throw new NotImplementedException();
    }

    public void Purchase(string productID, Action callbackSuccessful, Action callbackCancelled)
    {
        throw new NotImplementedException();
    }

    public void Purchase(string productID, Action callbackSuccessful)
    {
        throw new NotImplementedException();
    }
}
