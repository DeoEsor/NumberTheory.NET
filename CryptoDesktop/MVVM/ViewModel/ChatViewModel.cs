using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using CryptoDesktop.Annotations;
using CryptoDesktop.MVVM.Commands;
using CryptoDesktop.MVVM.Model;
using Microsoft.Win32;

namespace CryptoDesktop.MVVM.ViewModel;

public class ChatViewModel : INotifyPropertyChanged
{
    private ContactModel _selectedContact;
    private ContactModel _user;
    private string _message;
    public ObservableCollection<ContactModel> Contacts { get; set; } = new ObservableCollection<ContactModel>();
    
    public RelayCommand SendCommand { get; set; }
    public RelayCommand OpenFileCommand { get; set; }
    public RelayCommand ChoiceParamsCommand { get; set; }
    

    public ContactModel SelectedContact
    {
        get => _selectedContact;
        set
        {
            _selectedContact = value;
            OnPropertyChanged();
        }
    }

    public ContactModel User
    {
        get => _user;
        set
        {
            _user = value;
            OnPropertyChanged();
        }
    }

    public string Message
    {
        get => _message;
        set
        {
            _message = value;
            OnPropertyChanged();
        }
    }

    public ChatViewModel()
    {
        User = new ContactModel
        {
            Username = "User",
            Status = "Status",
            ImageSource = null!,
             
        };
        
        Contacts.Add(new ContactModel
        {
            Username = "Cat",
            Messages = 
                new ObservableCollection<MessageModel>
                {
                    new MessageModel
                    {
                        Username = "Cat",
                        UsernameColor = "White",
                        Message = new Message
                        {
                            MessageData = Encoding.UTF8.GetBytes("Мяу"),
                            Type = Model.Message.MessageType.String
                        },
                        Time = DateTime.Now,
                        IsNativeOrigin = true
                    },
                    new MessageModel
                    {
                        Username = "Cat",
                        UsernameColor = "White",
                        Message = new Message
                        {
                            MessageData = Encoding.UTF8.GetBytes("Мяу"), 
                            Type = Model.Message.MessageType.File,
                            FileName = "SecretMessage.txt"
                        },
                        Time = DateTime.Now,
                        IsNativeOrigin = true
                    }         
                }
        });
        SelectedContact = Contacts.First();
        SendCommand = new RelayCommand(o =>
        {
            if (Message == string.Empty) return;
            SelectedContact.Messages.Add( new MessageModel
            {
                Username = User.Username,
                ImageSource = User.ImageSource,
                Message = new Message
                {
                    MessageData = Encoding.UTF8.GetBytes(Message),
                    Type = Model.Message.MessageType.String
                },
                UsernameColor = "Red"
            });
            Message = string.Empty;
        });

        OpenFileCommand = new RelayCommand(o =>
        { 
            var dlg = new OpenFileDialog();
            dlg.Filter = "Documents (*.*)|*.*";

            var msg = new Message();
            if (dlg.ShowDialog() == true)
                msg = new Message
                {
                    FileName = dlg.FileName.Split('\\').Last(),
                    Type = Model.Message.MessageType.File,
                    MessageData = File.ReadAllBytes(dlg.FileName)
                };
            
            SelectedContact.Messages.Add(
                new MessageModel
                {
                    Username = User.Username,
                    Message = msg,
                    UsernameColor = "Red"
                }
                );
        });
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}