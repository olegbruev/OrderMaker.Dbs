/*
    MTD OrderMaker - http://ordermaker.org
    Copyright (c) 2019 Oleg Bruev <job4bruev@gmail.com>. All rights reserved.
*/

using System;

namespace Mtd.OrderMaker.Dbs.Entity
{
    public partial class MtdConfigFile
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public long FileSize { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
    }
}
