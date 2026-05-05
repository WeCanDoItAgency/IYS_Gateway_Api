using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AnlasmaliKurumlarAppointment
{
    public int Id { get; set; }

    public int KurumId { get; set; }

    public int UserId { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime AppointmentStart { get; set; }

    public DateTime AppointmentEnd { get; set; }

    public bool IsActive { get; set; }
}
