﻿using System.Collections.Generic;
namespace DocumentSystem.Models
{
    public class AudioDocument : MultimediaDocument, IDocument
    {
        public AudioDocument(string name, string content = null, int size = 0, int length = 0, double sampleRate = 0.0)
            : base(name, content, size, length)
        {
            this.SampleRate = sampleRate;
        }

        public double SampleRate { get; private set; }

        public override void LoadProperty(string key, string value)
        {
            if (key.ToLower() == "samplerate")
            { this.SampleRate = int.Parse(value); }
            else { base.LoadProperty(key, value); }
        }

        public override void SaveAllProperties(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, object>> output)
        {
            if (this.SampleRate != 0)
                output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
            base.SaveAllProperties(output);
        }
    }
}
