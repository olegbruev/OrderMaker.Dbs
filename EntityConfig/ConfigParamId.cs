using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mtd.OrderMaker.Dbs.EntityConfig
{
    public static class ConfigParamId
    {
        public static Guid ColorBar => Guid.Parse("5C03F4AD-421F-4AAB-A31B-02613C9B4D88");
        public static Guid ColorIcon => Guid.Parse("67E78F50-9B95-4F4B-B473-C78563FF7CFB");
        public static Guid DefaultCulture => Guid.Parse("87B5A4C1-3F3A-49C5-A997-9399077C7624");
        public static Guid SupportEmail => Guid.Parse("DA4B8E13-3DE0-4823-9F51-0869FCEEA4A6");
        public static Guid EmailFromName => Guid.Parse("58741995-C4FA-4160-9504-13932B4222E7");
        public static Guid EmailFromAddress => Guid.Parse("C2B2EE39-90CB-416B-8747-FA29DCD9F8BB");
        public static Guid EmailPassword => Guid.Parse("74C3AEDE-379C-4E9C-A3EC-D1D0DD94EAB3");
        public static Guid EmailSmtpServer => Guid.Parse("8585CAEF-FD6E-4F3D-9BC8-62220685E83A");
        public static Guid EmailSmtpPort => Guid.Parse("1C65626F-9D5F-4E4E-98DB-D71B2C1313B6");

        public static Guid FileImgMenu => Guid.Parse("FAD2368C-51F3-4A72-BD72-AD77CC8D3EE5");
        public static Guid FileImgAppBar => Guid.Parse("9F4F6F48-0E8E-4837-9B2C-6E1CBB09CD90");
    }
}
