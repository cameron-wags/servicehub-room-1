﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServiceHub.Room.Context.Repository
{
    /// <summary>
    /// Class to save rooms with an in memory data structure
    /// </summary>
    public class RoomRepositoryMemory:IRoomsRepository
    {
        public List<Models.Room> roomList = new List<Models.Room>();

        /// <summary>
        /// Method for inserting rooms into a list
        /// </summary>
        /// <param name="room"></param>
        public void Insert(Models.Room room)
        {
            roomList.Add(room);
        }

        /// <summary>
        /// Method to return all rooms from the list
        /// </summary>
        /// <returns>A list with all rooms within it. Returns an empty list of rooms.</returns>
        public List<Models.Room> Get()
        {
            return roomList;
        }

        /// <summary>
        /// Method to return a room by its Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns a Models.Room object. If no room exists it returns null</returns>
        public Models.Room GetById(Guid id)
        {
            Models.Room room = roomList.Find(x => x.RoomId == id);
            return room;
        }

        public void Update(Models.Room room)
        {
            int index = roomList.IndexOf(roomList.Single(x => x.RoomId == room.RoomId));
            if (index >= 0)
            roomList[index] = room;
        }

        public void Delete(Guid id)
        {
            roomList.Remove(roomList.Find(x => x.RoomId == id));
        }
    }
}
