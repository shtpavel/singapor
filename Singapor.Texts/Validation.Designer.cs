﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Singapor.Texts {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Validation {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Validation() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Singapor.Texts.Validation", typeof(Validation).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t create more then 20 units per request.
        /// </summary>
        public static string CantCreateMuchUnitsAtOneTime {
            get {
                return ResourceManager.GetString("CantCreateMuchUnitsAtOneTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t find required company.
        /// </summary>
        public static string CompanyNotFound {
            get {
                return ResourceManager.GetString("CompanyNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There is already defined schedule for this date.
        /// </summary>
        public static string DuplicateScheduleForDate {
            get {
                return ResourceManager.GetString("DuplicateScheduleForDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field should be from {0} to {1} charachers.
        /// </summary>
        public static string LengthBetween {
            get {
                return ResourceManager.GetString("LengthBetween", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Can&apos;t create child unit for non-container parent.
        /// </summary>
        public static string ParentUnitIsNotContainer {
            get {
                return ResourceManager.GetString("ParentUnitIsNotContainer", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This field is required.
        /// </summary>
        public static string Required {
            get {
                return ResourceManager.GetString("Required", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Already have the record with the same id.
        /// </summary>
        public static string UniqueId {
            get {
                return ResourceManager.GetString("UniqueId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unit not found.
        /// </summary>
        public static string UnitNotFound {
            get {
                return ResourceManager.GetString("UnitNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unit type not found.
        /// </summary>
        public static string UnitTypeNotFound {
            get {
                return ResourceManager.GetString("UnitTypeNotFound", resourceCulture);
            }
        }
    }
}
