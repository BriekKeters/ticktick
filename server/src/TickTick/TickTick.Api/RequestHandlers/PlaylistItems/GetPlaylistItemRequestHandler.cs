using System;
using MediatR;
using TickTick.Api.Dtos;
using TickTick.Repositories.Base;
using TickTick.Models;
using TickTick.Api.Dtos.Persons;

namespace TickTick.Api.RequestHandlers.PlaylistItems
{
	public class GetPlaylistItemRequest : QueryBase<PlaylistItemDto>
	{
        public Guid PublicId { get; }
        public PlaylistItemType Type { get; }

        public GetPlaylistItemRequest(Guid id,PlaylistItemType type)
		{
            PublicId = id;
            Type = type;
        }
    }
	public class GetPlaylistItemRequestHandler:IRequestHandler<GetPlaylistItemRequest,PlaylistItemDto>
	{
        private readonly IRepository<PlaylistItem> playlistRepository;

        public GetPlaylistItemRequestHandler(IRepository<PlaylistItem> PlaylistRepository)
		{
            playlistRepository = PlaylistRepository;
        }

        public async Task<PlaylistItemDto> Handle(GetPlaylistItemRequest request, CancellationToken cancellationToken)
        {
            PlaylistItem item = await playlistRepository.GetAsync(item => item.Type == request.Type && item.PublicId  == request.PublicId && item.IsDeleted == false);
            return item.ConvertToDto();
        }
    }
}

