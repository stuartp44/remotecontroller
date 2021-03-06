﻿namespace Ags.ProjectorController
{
    using System;

    /// <summary>
    /// This decorator is used to provide a wrapper around a controller to give global functionality around
    /// each method in the interface. Initially this is for raising message events but could be used for 
    /// exception handling and retrying etc.
    /// </summary>
    public class ControllerDecorator : IProjectorController
    {
        private readonly IProjectorController controller;

        public ControllerDecorator(IProjectorController controller)
        {
            this.controller = controller;

            // wire up the controller event to rebroadcast through the decorator
            // for controller specific messages
            controller.Message += (sender, s) =>
                { this.Message.Invoke(sender, s); };
        }

        public event EventHandler<string> Message;

        public string Make
        {
            get
            {
                return controller.Make;
            }
            set
            {
                controller.Make = value;
            }
        }

        public string Model
        {
            get
            {
                return controller.Model;
            }
            set
            {
                controller.Model = value;
            }
        }

        public void PowerOn()
        {
            this.Message.Invoke(controller, "Processing, please wait");
            controller.PowerOn();
            //this.Message.Invoke(controller, "Power On Complete");
        }

        public void PowerOff()
        {
            this.Message.Invoke(controller, "Processing, please wait");
            controller.PowerOff();
            //this.Message.Invoke(controller, "Power Off Complete");
        }

        public void ProjectorSelectRGB()
        {
            this.Message.Invoke(controller, "Processing, please wait");
            controller.ProjectorSelectRGB();
            //this.Message.Invoke(controller, "Select RGB Complete");
        }

        public void ProjectorSelectHDMI()
        {
            this.Message.Invoke(controller, "Processing, please wait");
            controller.ProjectorSelectHDMI();
            //this.Message.Invoke(controller, "Select HDMI Complete");
        }

        public void ProjectorFreeze()
        {
            this.Message.Invoke(controller, "Processing, please wait");
            controller.ProjectorFreeze();
            //this.Message.Invoke(controller, "Projector Freeze Complete");
        }

        public void ProjectorBlank()
        {
            this.Message.Invoke(controller, "Processing, please wait");
            controller.ProjectorBlank();
            //this.Message.Invoke(controller, "Projector Blank Complete");
        }

    }
}