﻿namespace TesteUber.Core.Emails.Model
{
    public record Email
    {
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
