using System;

namespace CryptoDesktop.MVVM.Model;

public class MessageModel
{
    public string Username { get; set; }
    public string UsernameColor { get; set; }
    public string ImageSource { get; set; }
    public Message Message { get; set; }
    
    
    public DateTime Time { get; set; }
    public bool IsNativeOrigin { get; set; }
    public bool IsFirstMessage { get; set; }
}