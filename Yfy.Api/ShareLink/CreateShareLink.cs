﻿namespace Yfy.Api.ShareLink
{
    using System;
    using Newtonsoft.Json;
    using System.ComponentModel;
    using Yfy.Api.Items;

    internal class CreateShareLinkArg
    {
        [JsonProperty("file_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(0)]
        public long FileId { get; set; }

        [JsonProperty("folder_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(0)]
        public long FolderId { get; set; }

        [JsonProperty("access")]
        [JsonConverter(typeof(LowerStringEnumConverter))]
        public ShareLinkAccess Access { get; set; }

        [JsonProperty("disable_download", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(false)]
        public bool DisableDownload { get; set; }

        [JsonProperty("due_time")]
        [JsonConverter(typeof(ChinaDateTimeConverter))]
        public DateTime DueTime { get; set; }

        [JsonProperty("password_protected", DefaultValueHandling = DefaultValueHandling.Ignore)]
        [DefaultValue(false)]
        public bool PasswordProtected { get; set; }

        [JsonProperty("password")]
        [DefaultValue(null)]
        public string Password { get; set; }

        public CreateShareLinkArg(long id, ItemType type, ShareLinkAccess access, DateTime dueTime, bool disableDownload = false, bool passwordProtected = false, string password = null)
        {
            if (type == ItemType.file)
            {
                this.FileId = id;
            }
            else if (type == ItemType.folder)
            {
                this.FolderId = id;
            }
            else
            {
                throw new ArgumentException("type can not be all, should be file or folder", nameof(type));
            }
            
            this.Access = access;
            this.DueTime = dueTime;
            this.DisableDownload = disableDownload;
            this.PasswordProtected = passwordProtected;
            this.Password = password;
        }
    }
}
