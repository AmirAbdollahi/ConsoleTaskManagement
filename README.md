# Console Task Management

This repository contains a simple console application for managing tasks. It allows users to create, view, update, and delete tasks using a command-line interface (CLI).

## Features

- **Task Management**: Add, view, update, and delete tasks.
- **Simple CLI**: Intuitive and easy-to-use command-line interface.
- **Persistent Storage**: Tasks are stored in a local file for persistence.

## Technologies Used

- **C#**: The application is built using C#.
- **File Storage**: Task data is stored in a local file.

## Setup

### Prerequisites

- **.NET SDK**: v8.0 or higher

### Installation

1. Clone the repository:
    ```bash
    git clone https://github.com/AmirAbdollahi/ConsoleTaskManagement.git
    cd ConsoleTaskManagement
    ```

2. Build the project:
    ```bash
    dotnet build
    ```

3. Run the application:
    ```bash
    dotnet run
    ```

### Using the Application

Once the application is running, you can use the following commands to manage your tasks:

- **Add a task**: `add <task_name>`
- **View all tasks**: `view`
- **Update a task**: `update <task_id> <new_task_name>`
- **Delete a task**: `delete <task_id>`

## Contributing

1. Fork this repository.
2. Create a new branch.
3. Make your changes.
4. Submit a pull request.

Please follow the coding standards and ensure that the application runs without issues before submitting a PR.

## License

This project is licensed under the MIT License.
