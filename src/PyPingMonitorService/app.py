import shlex  
from subprocess import Popen, PIPE, STDOUT

# https://pythonadventures.wordpress.com/tag/ping-time/
 
def get_simple_cmd_output(cmd, stderr=STDOUT):
    """
    Execute a simple external command and get its output.
    """
    args = shlex.split(cmd)
    return Popen(args, stdout=PIPE, stderr=stderr).communicate()[0]
 
def get_ping_time(host):
    host = host.split(':')[0]
    cmd = "fping {host} -C 10 -q".format(host=host)
    result = get_simple_cmd_output(cmd).decode('utf-8')
    print(result)
    return 1
    # res = [float(x) for x in result.strip().split(':')[-1].split() if x != '-']
    # printf()

    # if len(res) > 0:
    #     return sum(res) / len(res)
    # else:
    #     return 999999

ping_time = get_ping_time('www.seznam.cz')
#print(ping_time)
