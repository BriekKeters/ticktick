using System;
using MediatR;
using TickTick.Api.Dtos;
using TickTick.Repositories.Base;
using TickTick.Models;
using TickTick.Api.Dtos.Persons;

namespace TickTick.Api.RequestHandlers.PlaylistItems
{
	public class GetAllPlaylistItemRequest : QueryBase<IEnumerable<PlaylistItemDto>>
	{
        public PlaylistItemType Type { get; }

        public GetAllPlaylistItemRequest(PlaylistItemType type)
		{
            Type = type;
        }
    }
	public class GetAllPlaylistItemRequestHandler : IRequestHandler<GetAllPlaylistItemRequest,IEnumerable<PlaylistItemDto>>
	{
        private readonly IRepository<PlaylistItem> playlistRepository;

        public GetAllPlaylistItemRequestHandler(IRepository<PlaylistItem> PlaylistRepository)
		{
            playlistRepository = PlaylistRepository;
        }

        public async Task<IEnumerable<PlaylistItemDto>> Handle(GetAllPlaylistItemRequest request, CancellationToken cancellationToken)
        {
            var result = new List<PlaylistItemDto>();
            var items  = await playlistRepository.GetAllAsync(item => item.Type == request.Type && item.IsDeleted == false);
            foreach(var item in items)
            {
                result.Add(item.ConvertToDto());
            }
            return result;
        }
    }
}

