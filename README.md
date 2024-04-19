# 3D Human Passivity Analysis

>T. Hatanaka, T. Mochizuki, T. Sumino, J. M. Maestre and N. Chopra, "Human Modeling and Passivity Analysis for Semi-Autonomous Multi-Robot Navigation in Three Dimensions," in IEEE Open Journal of Control Systems, vol. 3, pp. 45-57, 2024, doi: 10.1109/OJCSYS.2023.3343598.
>[https://ieeexplore.ieee.org/document/10361530]()

## Setting

### Setting InputManager
![Inputmn](https://github.com/htnk-lab/3D-Human-Passivity-Analysis-Simulator/assets/51741181/074f670c-4999-4d51-b93c-5a14029bd24e)

- `Interface Type`:
  | Type  | Feedback Interface | Command Interface |
  | ----- | ------------------ | ----------------- |
  |  `1`  | 2-D display        | Joystick          |
  |  `2`  | 2-D display        | VR controller     |
  |  `3`  | HMD                | VR controller     |

- `Participant ID` : Participant's ID number, used for logging.
- `Exnum` :  Trial Count, used for logging.

## Output
The operation logs are stored in `Asset\Scenes\Saves` in the following json format.

```json
{
    "InterfaceType": 3,
    "ParticipantID": 0,
    "log": [
        {
            "time": 0.0,
            "y_h": {
                "x": 0.11657274514436722,
                "y": -0.10894632339477539,
                "z": -0.5159817934036255
            },
            "u_h": {
                "x": -0.00042617321014404297,
                "y": -0.000565648078918457,
                "z": 0.0007186830043792725
            },
            "drones": [
                {
                    "x": 0.11657274514436722,
                    "y": -0.10894632339477539,
                    "z": -0.5159817934036255
                },
               ...

            ],
            "ez": {
                "x": 0.4561498165130615,
                "y": 0.06232577562332153,
                "z": 0.17812836170196534
            },
            "gameCount": 1,
            "target": {
                "x": 0.5727225542068481,
                "y": -0.04662054777145386,
                "z": -0.33785343170166018
            }
        },
      ...
  ]
}
```

- `y_h`: Avarage position which displayed on the feedback interface.
- `u_h`: Command from human operator.
- `drones`: Position of each drone.
- `ez`: Error of target to y_h.
- `gameCount`: Number of target moves.
- `target`: Position of target

## Citation

```
@ARTICLE{10361530,
  author={Hatanaka, Takeshi and Mochizuki, Takahiro and Sumino, Takumi and Maestre, José M. and Chopra, Nikhil},
  journal={IEEE Open Journal of Control Systems}, 
  title={Human Modeling and Passivity Analysis for Semi-Autonomous Multi-Robot Navigation in Three Dimensions}, 
  year={2024},
  volume={3},
  number={},
  pages={45-57},
  keywords={Robots;Solid modeling;Navigation;Analytical models;Control systems;Task analysis;Human in the loop;Distributed control;human–robot collaborations;passivity;semi-autonomous multi–robot navigation;system identification;virtual reality},
  doi={10.1109/OJCSYS.2023.3343598}}
```
