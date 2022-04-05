using AutoMapper;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WslDockerTool.Net5.Models;
using WslDockerTool.Net5.Models.Container;
using WslDockerTool.Net5.Models.Image;
using WslDockerTool.Net5.Models.Network;
using WslDockerTool.Net5.Models.PortProxy;
using WslDockerTool.Net5.Models.Volume;
using WslDockerTool.Net5.ViewModels.Container;
using WslDockerTool.Net5.ViewModels.PortProxy;
using WslDockerTool.Shared.Models;

namespace WslDockerTool.Net5.Core
{
	public class MappingProfile:Profile
	{
		public MappingProfile()
		{
			// 
			//CreateMap<ImageListItemModel, ImagesListResponse>()
			//	//.BeforeMap((src, dest) => src.Name = dest.RepoTags[0])
			//	//.ForMember(dst => dst.RepoTags, opt => opt.MapFrom(src => src.Name))
			//	.AfterMap((src, dest) => src.Name= dest.RepoTags[0])
			//	//.ForPath(s => s.RepoTags, opt => opt.Ignore())
			//	.ReverseMap();

			CreateMap<ImagesListResponse, ComboBoxSelectItem>()
				.AfterMap((src, dest) => dest.Name = src.RepoTags.Any() ? src.RepoTags[0] : string.Empty)
				.AfterMap((src,dest)=>dest.Value=src.ID);
			CreateMap<ImagesListResponse, ImageListItemModel>()
				.AfterMap((src, dest) => dest.Name = src.RepoTags.Any() ? src.RepoTags[0] : string.Empty);
			CreateMap<NetworkResponse, NetworkListItemModel>();
			CreateMap<VolumeResponse, VolumeListItemModel>()
				.AfterMap((src, dest) => dest.Created = DateTime.Parse(src.CreatedAt));
			CreateMap<ContainerListResponse, ContainerListItemModel>();
			CreateMap<Docker.DotNet.Models.Port, WslDockerTool.Net5.Models.Container.Port>();
			//.AfterMap((src, dest) => dest.Created = DateTime.Parse(src.CreatedAt));

			CreateMap< ImageListItemModel, ImageInfo>();
			CreateMap<PortProxyItem, PortProxyListItemModel>();
			CreateMap<PortProxyListItemModel, DeletePortProxyParameters>();
			CreateMap<CreatePortProxyViewModel, PortProxyItem>();
			CreateMap<PortProxyItem, CreatePortProxyViewModel>(); 
	
			CreateMap<CreateContainerViewModel, CreateContainerParameters>()
				.ForMember(dest => dest.Volumes, opt => opt.Ignore())
				.AfterMap((src, dest) => dest.Image = src.ImageId)
				.AfterMap((src, dest) => dest.Name = src.ContainerName)
                .AfterMap((src, dest) =>
                {
                    if (!string.IsNullOrEmpty(src.Ports))
                    {
                        var posts = src.Ports.Split('|');
						dest.HostConfig = new HostConfig();
						dest.HostConfig.PortBindings = new Dictionary<string, IList<PortBinding>>();
						foreach (var post in posts)
						{ 
							var tposts = post.Split(':');
                            if (tposts.Length==2)
                            {
								dest.HostConfig.PortBindings.Add($"{tposts[1]}/tcp", new List<PortBinding>()
								{
									new PortBinding() { HostPort = tposts[0]  }
								});
								//dest.HostConfig.PortBindings.Add($"{tposts[0]}/tcp", new List<PortBinding>()
								//{
								//	new PortBinding() { HostPort = tposts[0]  }
								//});
							}
							
						}
                    }

                })
                .AfterMap((src, dest) => {
                    if (!string.IsNullOrEmpty(src.Envs))
                    {
                        var envs = src.Envs.Split('|');
                        dest.Env = envs;
                    }

                })
				 .AfterMap((src, dest) => {
					 if (!string.IsNullOrEmpty(src.Volumes))
					 {
						 var volumes = src.Volumes.Split('|');
						 dest.HostConfig.Mounts = new List<Mount>();
						 foreach (var volume in volumes)
						 {
							 var tvolumes = volume.Split(':');
							 dest.HostConfig.Mounts.Add(new Mount() { Source=tvolumes[0],Target= tvolumes[1],Type= "volume" });
						 }
					 }

				 });
		
		}
	}
}
