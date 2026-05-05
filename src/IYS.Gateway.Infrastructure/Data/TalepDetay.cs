using System;
using System.Collections.Generic;

namespace IYS.Gateway.Infrastructure.Data;

public partial class TalepDetay
{
    public int Id { get; set; }

    public int? RequestId { get; set; }

    public string? Description { get; set; }

    public int? SenderUserId { get; set; }

    public int? ReplierByUserId { get; set; }

    public int? ReadBy { get; set; }

    public string? UploadFile { get; set; }

    public string? UploadFilePath { get; set; }

    public DateTime? CreateDate { get; set; }

    public bool IsFirmConversation { get; set; }

    public bool? IsSystemMessage { get; set; }

    public string? ConversationId { get; set; }

    public virtual Talepler? Request { get; set; }
}
