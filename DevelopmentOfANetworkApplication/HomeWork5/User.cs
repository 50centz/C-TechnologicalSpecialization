﻿namespace Seminar5
{
    public class User
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public virtual List<Message>? MessagesTo { get; set; } = new();
        public virtual List<Message>? MessagesFrom { get; set; } = new();

    }
}
