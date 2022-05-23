using System;

namespace VideoVault.WebUI.Models
{
    public class ConfirmationArgumentsModel
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public Func<bool>  OnConfirm { get; set; }
    }
}
