using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Application.Common;

namespace Blog.Application.Services.PostGroups.Commands.ActiveGroup
{
    public record ActivePostGroupCommand(long GroupId) : IBaseRequest, ICommitTableRequest;
}
