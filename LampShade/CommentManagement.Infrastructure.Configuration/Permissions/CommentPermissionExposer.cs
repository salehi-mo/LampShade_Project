using System.Collections.Generic;
using _0_Framework.Infrastructure;

namespace CommentManagement.Configuration.Permissions
{
    public class CommentPermissionExposer : IPermissionExposer
    {
        public Dictionary<List<string>, List<PermissionDto>> Expose()
        {
            return new Dictionary<List<string>, List<PermissionDto>>
            {
                {
                    new List<string>()
                   {
                       "Comments",
                       "کامنت ها"
                   },
                   new List<PermissionDto>
                    {
                        new PermissionDto(CommentPermissions.ListComments ,  "ListComments","لیست کامنت ها"),
                        new PermissionDto(CommentPermissions.SearchComments, "SearchComments","جستجوی کامنت"),
                        new PermissionDto(CommentPermissions.CancleComment, "CancleComment","کنسل/تایید کامنت"),
                        
                    }
                }
            };
        }
    }
}