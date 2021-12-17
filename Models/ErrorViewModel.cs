// Dhruvil Chaudhari (100802514)
// reference: Prof. Alaadin Addas
// https://durhamcollege.desire2learn.com/d2l/le/content/390094/viewContent/5208532/View

using System;

namespace ASPDatabase.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
