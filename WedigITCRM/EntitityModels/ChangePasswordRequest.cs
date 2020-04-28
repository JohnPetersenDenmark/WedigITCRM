using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WedigITCRM
{
    public class ChangePasswordRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public DateTime RequestDateTime { get; set; }

        public Guid LinkRequestId { get; set; }

        public string SendToEmail { get; set; }

    }
}
