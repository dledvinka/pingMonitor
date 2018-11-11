from flask import Flask, request, jsonify
from flask_sqlalchemy import SQLAlchemy
from flask_marshmallow import Marshmallow
import os

app = Flask(__name__)
basedir = os.path.abspath(os.path.dirname(__file__))
app.config['SQLALCHEMY_DATABASE_URI'] = 'sqlite:///' + os.path.join(basedir, 'crud.sqlite')
db = SQLAlchemy(app)
ma = Marshmallow(app)


class PingResult(db.Model):
    id = db.Column(db.Integer, primary_key=True)
    timeElapsedMs = db.Column(db.Integer)
    status = db.Column(db.String(20))

    def __init__(self, timeElapsedMs, status):
        self.timeElapsedMs = timeElapsedMs
        self.status = status


class PingResultSchema(ma.Schema):
    class Meta:
        # Fields to expose
        fields = ('timeElapsedMs', 'status')


pingResult_schema = PingResultSchema()
pingResults_schema = PingResultSchema(many=True)


# endpoint to create new user
@app.route("/pingresult", methods=["POST"])
def add_pingresult():
    timeElapsedMs = request.json['timeElapsedMs']
    status = request.json['status']
    
    new_pingResult = PingResult(timeElapsedMs, status)

    db.session.add(new_pingResult)
    db.session.commit()

    return jsonify(new_pingResult)


# endpoint to show all users
@app.route("/pingresult", methods=["GET"])
def get_pingresult():
    all_pingresults = PingResult.query.all()
    result = pingResults_schema.dump(all_pingresults)
    return jsonify(result.data)


# endpoint to get user detail by id
@app.route("/pingresult/<id>", methods=["GET"])
def pingresult_detail(id):
    pingresult = PingResult.query.get(id)
    return ping_schema.jsonify(user)


# endpoint to update user
@app.route("/pingresult/<id>", methods=["PUT"])
def pingresult_update(id):
    pingresult = PingResult.query.get(id)
    timeElapsedMs = request.json['timeElapsedMs']
    status = request.json['status']

    pingresult.timeElapsedMs = timeElapsedMs
    pingresult.status = status

    db.session.commit()
    return ping_schema.jsonify(pingresult)


# # endpoint to delete user
# @app.route("/user/<id>", methods=["DELETE"])
# def user_delete(id):
#     user = User.query.get(id)
#     db.session.delete(user)
#     db.session.commit()

#     return ping_schema.jsonify(user)


if __name__ == '__main__':
    app.run(debug=True)