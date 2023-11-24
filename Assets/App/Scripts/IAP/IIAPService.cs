using System;

public interface IIAPService
{
    public void Purchase(string productID, Action callbackSuccessful, Action callbackCancelled, Action callbackError);
    public void Purchase(string productID, Action callbackSuccessful, Action callbackCancelled);
    public void Purchase(string productID, Action callbackSuccessful);
}
