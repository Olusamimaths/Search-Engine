using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace UploaderUtil
{
    public class DocumentEntry
    {
        public ObjectId _id { get; set; }
        public int DocID { get; set; }
        public string Path { get; set; }
    }
}
