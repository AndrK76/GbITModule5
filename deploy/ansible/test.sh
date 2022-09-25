#!/bin/bash

ansible -i ./inventory all 
ansible-playbook ./inventory local nginx0.yml
