#!flask/bin/python
from flask import Flask, jsonify
import socket
import datetime

app = Flask(__name__)

batches = [
    {
        'id': 1,
        'machineName': socket.gethostname(),
        'timestamp': datetime.datetime.now(),
        'pingTimeoutMs': 4000,
        'intervalBetweenPingsMs': 5000,
        'results': [
            {
                'id': 1
            }
        ]
    }
]

@app.route('/todo/api/v1.0/tasks', methods=['GET'])
def get_tasks():
    return jsonify({'batches': batches})

if __name__ == '__main__':
    app.run(debug=True)
