using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskHive.Api.Projects.Models;

public record ProjectDto(string title, string description, DateTime dueDate, DateTime createdOn);