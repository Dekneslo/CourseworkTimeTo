using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts.LikeContracts
{
    public class LikeRequest
    {
        public int UserId { get; set; }
        public int EntityId { get; set; } // Это будет ID курса или поста
    }
}
