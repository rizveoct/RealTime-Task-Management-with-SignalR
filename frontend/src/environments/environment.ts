export const environment = {
  production: false,
  apiUrl: 'https://localhost:5001',
  signalR: {
    taskHub: '/hubs/tasks',
    notificationHub: '/hubs/notifications',
    boardHub: '/hubs/boards',
    chatHub: '/hubs/chat',
    presenceHub: '/hubs/presence'
  }
};
