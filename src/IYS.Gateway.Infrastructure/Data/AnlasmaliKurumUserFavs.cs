using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class AnlasmaliKurumUserFavs
{
    public int Id { get; set; }

    public int KurumId { get; set; }

    public int UserId { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual AnlasmaliKurumlar Kurum { get; set; } = null!;

    public virtual Kullanicilar User { get; set; } = null!;
}
