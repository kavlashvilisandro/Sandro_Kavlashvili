using EventsItAcademyGe.Domain.Exceptions;
using System.Runtime.InteropServices;
using System.Text;


namespace EventsItAcademyGe.MVC.Models
{
    public unsafe struct ErrorViewModel : IDisposable
    {
        private IntPtr ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public int MessageLength { get; set; }

        public ErrorViewModel(APIRequestError error)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(error.Message);
            ErrorMessage = Marshal.AllocHGlobal(messageBytes.Length);//Allocates messageBytes.Length bytes in and returns
                                                                     //starter pointer memorry
            Marshal.Copy(messageBytes, 0, ErrorMessage, messageBytes.Length);
            MessageLength = messageBytes.Length;
            StatusCode = error.GetStatusCode();
        }

        public string GetErrorMessage()
        {
            byte[] buffer = new byte[MessageLength];
            Marshal.Copy(ErrorMessage, buffer, 0, MessageLength);
            return Encoding.UTF8.GetString(buffer);
        }

        public void Dispose()
        {
            Console.WriteLine();//Delete
            Marshal.FreeHGlobal(ErrorMessage);
        }
    }
}
